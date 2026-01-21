import z from "zod";
import { requiredString } from "../util/util";

export const resetPasswordSchema = z.object({
    newPassword: requiredString('New password'),
    confirmPassword: requiredString('Confirm password')
})
.refine((data) => data.newPassword === data.confirmPassword, {
    message: 'Passwords must match',
    path: ['confirmPassword']
})

export type ResetPasswordSchema = z.infer<typeof resetPasswordSchema>