using ClassLibrary1.Models;

namespace ClassLibrary1.Repositories;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetContactsAsync(int pageNumber, int pageSize);
    Task<IEnumerable<Contact>> SearchContactAsync(string name, int pageNumber, int pageSize);
    Task<Contact?> GetContactByIdAsync(int id);
    Task<Contact> CreateContactAsync(Contact contact);
    Task<bool> UpdateContactAsync(Contact contact);
    Task<bool> DeleteContactAsync(int id);
}