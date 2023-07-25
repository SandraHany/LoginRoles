CREATE MIGRATION m1txv3y3bz3mp2kagbno35y6jjtw754fmdbuogrtjynse7vpmyki7q
    ONTO m1wrjemispi6gpa7fuqrfpdiev3jevlz4lfqvg6mh644cnsgfufizq
{
  ALTER TYPE default::Contact {
      ALTER PROPERTY DateofBirth {
          RENAME TO date_of_birth;
      };
  };
  ALTER TYPE default::Contact {
      ALTER PROPERTY Description {
          RENAME TO description;
      };
  };
  ALTER TYPE default::Contact {
      ALTER PROPERTY Email {
          RENAME TO email;
      };
  };
  ALTER TYPE default::Contact {
      ALTER PROPERTY FirstName {
          RENAME TO first_name;
      };
  };
  ALTER TYPE default::Contact {
      ALTER PROPERTY IsMarried {
          RENAME TO is_married;
      };
  };
  ALTER TYPE default::Contact {
      ALTER PROPERTY LastName {
          RENAME TO last_name;
      };
  };
  ALTER TYPE default::Contact {
      ALTER PROPERTY Password {
          RENAME TO password;
      };
  };
  ALTER TYPE default::Contact {
      ALTER PROPERTY Role {
          RENAME TO role;
      };
  };
  ALTER TYPE default::Contact {
      ALTER PROPERTY Title {
          RENAME TO title;
      };
  };
  ALTER TYPE default::Contact {
      ALTER PROPERTY Username {
          RENAME TO user_name;
      };
  };
  ALTER SCALAR TYPE default::Email RENAME TO default::email;
  ALTER SCALAR TYPE default::Title RENAME TO default::title;
};
