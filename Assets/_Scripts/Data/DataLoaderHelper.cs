using System.Threading;
using Cysharp.Threading.Tasks;

public class DataLoaderHelper {
    IDataServer dataServerMock;

    CancellationTokenSource cancellationTokenSource;
    public void LoadData() {
        cancellationTokenSource = new();
        dataServerMock = new DataServerMock();
    }

    public async UniTask<int> GetItemsCount() {
        return await dataServerMock.DataAvailable(cancellationTokenSource.Token);
    }
}
