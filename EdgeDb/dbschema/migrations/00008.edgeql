CREATE MIGRATION m1wrjemispi6gpa7fuqrfpdiev3jevlz4lfqvg6mh644cnsgfufizq
    ONTO m1m4zm7ogoqory6jxaeramb2b4xozuplfgapsw6evfaabj7zvfpcla
{
  ALTER TYPE default::Contact {
      CREATE REQUIRED PROPERTY Password: std::str {
          SET REQUIRED USING (<std::str>{});
      };
      CREATE REQUIRED PROPERTY Role: std::str {
          SET REQUIRED USING (<std::str>{});
      };
      CREATE REQUIRED PROPERTY Username: std::str {
          SET REQUIRED USING (<std::str>{});
          CREATE CONSTRAINT std::exclusive;
      };
  };
};
