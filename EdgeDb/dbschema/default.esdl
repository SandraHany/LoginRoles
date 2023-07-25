module default {
    scalar type email extending str {
        constraint max_len_value(254);
        constraint min_len_value(3);
    }
    scalar type title extending enum<Mr, Mrs, Ms, Dr>;
    type Contact {
        required first_name: str;
        required last_name: str;
        required email: str {
          constraint exclusive;
        };
        required username: str {
            constraint exclusive;
        };
        required password: str;
        required role: str; 
        required title: str;
        description: str;
        date_of_birth: str;
        is_married: bool;
    }
}
