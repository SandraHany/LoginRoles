CREATE MIGRATION m1hrthrpnda53ixz5zmdx2g6u423hp7swvpigfnymfwzssy7m63yca
    ONTO m1wpgomeos2lplmclccbyiobl4bjrraoojciufr7zsqc5il34rfrqq
{
  ALTER TYPE default::Contact {
      ALTER PROPERTY date_of_birth {
          RENAME TO DateofBirth;
      };
  };
  ALTER TYPE default::Contact {
      ALTER PROPERTY description {
          RENAME TO Description;
      };
  };
  ALTER TYPE default::Contact {
      ALTER PROPERTY email {
          RENAME TO Email;
      };
  };
  ALTER TYPE default::Contact {
      ALTER PROPERTY first_name {
          RENAME TO FirstName;
      };
  };
  ALTER TYPE default::Contact {
      ALTER PROPERTY is_married {
          RENAME TO IsMarried;
      };
  };
  ALTER TYPE default::Contact {
      ALTER PROPERTY title {
          RENAME TO Title;
      };
  };
  ALTER SCALAR TYPE default::email RENAME TO default::Email;
};
