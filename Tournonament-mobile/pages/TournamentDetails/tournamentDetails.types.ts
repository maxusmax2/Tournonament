export  type Tournament = {
  name:number,
  participantNumber:number,
  participantNumberMax: number,
  status: number
  date: string | undefined
  participants: Array<any>
  description: string
  creatorId: number
  withGroupStep: boolean
}