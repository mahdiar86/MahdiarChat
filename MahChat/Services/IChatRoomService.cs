using MahChat.Models;

namespace MahChat.Services
{
    public interface IChatRoomService
    {
        Task<Guid> CreateRoom(string connectionId);

        Task<Guid> GetRoomForConnectionId(string connectionId);

        Task SetRoomName(Guid roomId, string name);

        Task<IEnumerable<ChatMessage>> GetMessageHistory(Guid roomId);

        Task AddMessage(Guid roomId, ChatMessage message);

        Task<IReadOnlyDictionary<Guid, ChatRoom>> GetAllRooms();
    }
}
