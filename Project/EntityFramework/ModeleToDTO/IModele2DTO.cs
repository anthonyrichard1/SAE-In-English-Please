namespace ModeleToDTO
{
    public interface IModele2DTO<T, TModele>
    {
        Task<IEnumerable<T>> Gets();
        Task<T> GetById(int id);
        Task<T> Add(TModele group);
        Task<T> Delete(int id);
        Task<T> Update(TModele group);


    }
}
