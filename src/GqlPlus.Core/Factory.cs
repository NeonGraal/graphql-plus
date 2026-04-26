namespace GqlPlus;

public delegate T Factory<out T, TRepo>(TRepo parsers)
  where T : class;
