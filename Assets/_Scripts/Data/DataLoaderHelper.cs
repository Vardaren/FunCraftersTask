using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Zenject;

public class DataLoaderHelper {
    [Inject] DataLoaderDataStore dataLoaderDS;

    IDataServer dataServerMock;

    CancellationTokenSource cancellationTokenSource;
    public void SetupServer() {
        cancellationTokenSource = new();
        dataServerMock = new DataServerMock();
    }

    public async UniTask<int> GetItemsCount() => await dataServerMock.DataAvailable(cancellationTokenSource.Token);

    public async UniTask<IList<DataItem>> RequestData() => await dataServerMock.RequestData(dataLoaderDS.indexToLoad, dataLoaderDS.ITEMS_TO_SHOW, cancellationTokenSource.Token);
}
