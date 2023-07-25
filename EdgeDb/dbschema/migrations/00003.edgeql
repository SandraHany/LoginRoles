CREATE MIGRATION m1yn5yvtpjtfxc55sy464vkuuixbngn5q4u75czypztgilkdy3e7dq
    ONTO m14bfvegq2u45acxkh2frwgbtvkdtzjegd73xus4vdsxcbfm4tratq
{
  ALTER SCALAR TYPE default::email {
      DROP CONSTRAINT std::regexp(r'^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$');
  };
};
