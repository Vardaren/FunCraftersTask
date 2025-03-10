using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Zenject;

public class DataLoaderHelper {
    [Inject] DataLoaderDataStore dataLoaderDS;

    IDataServer dataServerMock;

    public Action<IList<DataItem>> itemsLoaded;

    CancellationTokenSource cancellationTokenSource;

    public void SetupServer() {
        cancellationTokenSource = new();
        dataServerMock = new DataServerMock();
    }

    public async UniTask<int> GetItemsCount() => await dataServerMock.DataAvailable(cancellationTokenSource.Token);

    public async UniTask RequestData() {
        var itemsLeft = dataLoaderDS.availableDataCount - dataLoaderDS.indexToLoad;
        var itemsToLoad = itemsLeft < dataLoaderDS.ITEMS_TO_SHOW ? itemsLeft : dataLoaderDS.ITEMS_TO_SHOW;
        itemsLoaded?.Invoke(await dataServerMock.RequestData(dataLoaderDS.indexToLoad, itemsToLoad, cancellationTokenSource.Token));
    }
}
