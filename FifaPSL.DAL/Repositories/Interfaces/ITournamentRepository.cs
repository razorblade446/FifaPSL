namespace FifaPSL.DAL.Repositories.Interfaces
{
    public interface ITournamentRepository: IBaseRepository
    {
        tournament[] getTournaments();
        tournament getTournament(int tournamentId);
        tournament getTournamentCurrent();
        GetMatchesByTournamentId_Result[] getTournamentMatches(int tournamentId);
    }
}