//HintName: test_-Schema_Impl.gen.cs
// Generated from -Schema.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp__Schema;

public class Outputtest_Schema
  : Outputtest_Named
  , Itest_Schema
{
  public _Categories categories { get; set; }
  public _Directives directives { get; set; }
  public _Type types { get; set; }
  public _Setting settings { get; set; }
}

public class Domaintest_Identifier
  : Itest_Identifier
{
}

public class Inputtest_Filter
  : Itest_Filter
{
  public _NameFilter names { get; set; }
  public Boolean matchAliases { get; set; }
  public _NameFilter aliases { get; set; }
  public Boolean returnByAlias { get; set; }
  public Boolean returnReferencedTypes { get; set; }
  public _NameFilter As_NameFilter { get; set; }
}

public class Domaintest_NameFilter
  : Itest_NameFilter
{
}

public class Inputtest_CategoryFilter
  : Inputtest_Filter
  , Itest_CategoryFilter
{
  public _Resolution resolutions { get; set; }
}

public class Inputtest_TypeFilter
  : Inputtest_Filter
  , Itest_TypeFilter
{
  public _TypeKind kinds { get; set; }
}

public class Dualtest_Aliased
  : Dualtest_Named
  , Itest_Aliased
{
  public _Identifier aliases { get; set; }
}

public class Dualtest_Named
  : Dualtest_Described
  , Itest_Named
{
  public _Identifier name { get; set; }
}

public class Dualtest_Described
  : Itest_Described
{
  public String description { get; set; }
}
