import { Match } from "../Match/Match.types"

export  type  CloseMatchProps =
{
  match: Match
  visibleChange: (state:boolean)=>void
}
export type CloseMatchTypesFormType =
{
  scoreOne:number,
  scoreTwo:number,
}