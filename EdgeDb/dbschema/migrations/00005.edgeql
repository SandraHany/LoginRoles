CREATE MIGRATION m1wpgomeos2lplmclccbyiobl4bjrraoojciufr7zsqc5il34rfrqq
    ONTO m135ms3qgrkwbatss677tq7msfchyufhuhgaxhc5ubni524bj44bpq
{
  ALTER TYPE default::Contact {
      ALTER PROPERTY email {
          CREATE CONSTRAINT std::exclusive;
      };
  };
};
