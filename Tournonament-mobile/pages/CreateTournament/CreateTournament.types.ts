export type CreateTournamentTypesFormType = {
    Name: string,
    Date:string,
    ParticipantNumberMax: number,
    PrizeFund: string,
    Description: string,
    Format:number
    WithGroupStep: boolean
    GroupNumber: number
    Location: string
    NumberLeavingTheGroup: number
    CreatorId : number
    Discipline: string
}