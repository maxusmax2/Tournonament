export type MatchProps = {
  id:bigint
}
export type Match =
{
    id: bigint
    status :number
    participants: Array<any>
    scores: Array<any>
    tournamentId: number
}