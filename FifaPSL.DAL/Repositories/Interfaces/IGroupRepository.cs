namespace FifaPSL.DAL.Repositories.Interfaces
{
    public interface IGroupRepository: IBaseRepository
    {

        group getGroup(int groupId);

        group[] getGroups();

        int[] getGroupIdsByTournamentId(int tournamentId);
    }
}