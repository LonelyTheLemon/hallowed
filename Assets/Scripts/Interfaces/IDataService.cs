interface IDataService {
    bool SaveData<T>(string relativePath, T data);
    T LoadData<T>(string relativePath);
}