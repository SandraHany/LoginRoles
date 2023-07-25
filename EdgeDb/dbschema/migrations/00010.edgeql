CREATE MIGRATION m1gmivx5pyn5vb6cfsfuvjtwffzeubenezybnyoe2cfgvm6jp3t3eq
    ONTO m1txv3y3bz3mp2kagbno35y6jjtw754fmdbuogrtjynse7vpmyki7q
{
  ALTER TYPE default::Contact {
      ALTER PROPERTY user_name {
          RENAME TO username;
      };
  };
};
