//HintName: test_Declarations_Impl.gen.cs
// Generated from Declarations.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_Declarations;

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
