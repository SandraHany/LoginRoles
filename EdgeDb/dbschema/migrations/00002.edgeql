CREATE MIGRATION m14bfvegq2u45acxkh2frwgbtvkdtzjegd73xus4vdsxcbfm4tratq
    ONTO m1q33sxakhj5twq6q5obpat5znnh72mhb4ipw6h3k2l3ulc2iuho2q
{
  ALTER TYPE default::User RENAME TO default::Contact;
};
