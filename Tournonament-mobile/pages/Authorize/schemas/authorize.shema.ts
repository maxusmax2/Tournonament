import { z } from 'zod'
import type { ZodType } from 'zod'

export type AuthorizeFormType = {
    login: string,
    password:string
}

export const authorizeSchema: ZodType<AuthorizeFormType> = z.object({
    login: z.string().min(2).max(100),
    password: z.string().min(2).max(100)
})