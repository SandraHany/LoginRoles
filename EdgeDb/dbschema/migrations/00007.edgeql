CREATE MIGRATION m1m4zm7ogoqory6jxaeramb2b4xozuplfgapsw6evfaabj7zvfpcla
    ONTO m1hrthrpnda53ixz5zmdx2g6u423hp7swvpigfnymfwzssy7m63yca
{
  ALTER TYPE default::Contact {
      ALTER PROPERTY last_name {
          RENAME TO LastName;
      };
  };
};
