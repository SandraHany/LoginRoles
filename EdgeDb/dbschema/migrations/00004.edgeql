CREATE MIGRATION m135ms3qgrkwbatss677tq7msfchyufhuhgaxhc5ubni524bj44bpq
    ONTO m1yn5yvtpjtfxc55sy464vkuuixbngn5q4u75czypztgilkdy3e7dq
{
  ALTER TYPE default::Contact {
      ALTER PROPERTY date_of_birth {
          SET TYPE std::str USING (<std::str>.date_of_birth);
      };
      ALTER PROPERTY email {
          DROP CONSTRAINT std::exclusive;
          SET TYPE std::str;
      };
      ALTER PROPERTY title {
          SET TYPE std::str USING (<std::str>.title);
      };
  };
};
