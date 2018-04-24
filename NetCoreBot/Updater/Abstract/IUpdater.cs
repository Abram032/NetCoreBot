using System.Threading.Tasks;

namespace NetCoreBot.Updater.Abstract
{
    public interface IUpdater
    {
        Task UpdateFiles();
    }
}
