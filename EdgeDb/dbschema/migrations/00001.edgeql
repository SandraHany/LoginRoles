CREATE MIGRATION m1q33sxakhj5twq6q5obpat5znnh72mhb4ipw6h3k2l3ulc2iuho2q
    ONTO initial
{
  CREATE SCALAR TYPE default::Title EXTENDING enum<Mr, Mrs, Ms, Dr>;
  CREATE SCALAR TYPE default::email EXTENDING std::str {
      CREATE CONSTRAINT std::max_len_value(254);
      CREATE CONSTRAINT std::min_len_value(3);
      CREATE CONSTRAINT std::regexp(r'^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$');
  };
  CREATE TYPE default::User {
      CREATE PROPERTY date_of_birth: cal::local_date;
      CREATE PROPERTY description: std::str;
      CREATE REQUIRED PROPERTY email: default::email {
          CREATE CONSTRAINT std::exclusive;
      };
      CREATE REQUIRED PROPERTY first_name: std::str;
      CREATE PROPERTY is_married: std::bool;
      CREATE REQUIRED PROPERTY last_name: std::str;
      CREATE REQUIRED PROPERTY title: default::Title;
  };
};
