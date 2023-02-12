import { Pizza } from "./pizza";
import { User } from "./user";

export interface Order {
    pizzas: Pizza[];
    user: User;
    value: number
}