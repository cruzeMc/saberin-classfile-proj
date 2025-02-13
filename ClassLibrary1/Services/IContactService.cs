using ClassLibrary1.DTOs;

namespace ClassLibrary1.Services;

public interface IContactService
{
    Task<IEnumerable<ContactDTO>> GetContactsAsync(int pageNumber, int pageSize);
    Task<IEnumerable<ContactDTO>> SearchContactAsync(string name, int pageNumber, int pageSize);
    Task<ContactDTO> GetContactByIdAsync(int id);
    Task<ContactDTO> CreateContactAsync(ContactDTO contact);
    Task<bool> UpdateContactAsync(int id, ContactDTO contact);
    Task<bool> DeleteContactAsync(int id);
}