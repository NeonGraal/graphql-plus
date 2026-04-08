//HintName: test_Declarations_Enc.gen.cs
// Generated from {CurrentDirectory}Declarations.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Declarations;

public class test_Schema
  : test_Named
  , Itest_Schema
{
  public Itest_SchemaObject? As__Schema { get; set; }
}

public class test_SchemaObject
  : test_NamedObject
  , Itest_SchemaObject
{
  public IDictionary<Itest_Name, Itest_Categories>? Categories(Itest_CategoryFilter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Directives>? Directives(Itest_Filter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Type>? Types(Itest_TypeFilter? parameter)
    => null;
  public IDictionary<Itest_Name, Itest_Setting>? Settings(Itest_Filter? parameter)
    => null;

  public test_SchemaObject
    ()
  {
  }
}

public class test_Name
  : GqlpDomainString
  , Itest_Name
{
}

public class test_Filter
  : GqlpEncoderBase
  , Itest_Filter
{
  public ICollection<Itest_NameFilter>? As_NameFilter { get; set; }
  public Itest_FilterObject? As__Filter { get; set; }
}

public class test_FilterObject
  : GqlpEncoderBase
  , Itest_FilterObject
{
  public ICollection<Itest_NameFilter> Names { get; set; }
  public bool? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public bool? ReturnByAlias { get; set; }
  public bool? ReturnReferencedTypes { get; set; }

  public test_FilterObject
    ( ICollection<Itest_NameFilter> names
    , ICollection<Itest_NameFilter> aliases
    )
  {
    Names = names;
    Aliases = aliases;
  }
}

public class test_NameFilter
  : GqlpDomainString
  , Itest_NameFilter
{
}

public class test_CategoryFilter
  : test_Filter
  , Itest_CategoryFilter
{
  public Itest_CategoryFilterObject? As__CategoryFilter { get; set; }
}

public class test_CategoryFilterObject
  : test_FilterObject
  , Itest_CategoryFilterObject
{
  public ICollection<Itest_Resolution> Resolutions { get; set; }

  public test_CategoryFilterObject
    ( ICollection<Itest_NameFilter> names
    , ICollection<Itest_NameFilter> aliases
    , ICollection<Itest_Resolution> resolutions
    ) : base(names, aliases)
  {
    Resolutions = resolutions;
  }
}

public class test_TypeFilter
  : test_Filter
  , Itest_TypeFilter
{
  public Itest_TypeFilterObject? As__TypeFilter { get; set; }
}

public class test_TypeFilterObject
  : test_FilterObject
  , Itest_TypeFilterObject
{
  public ICollection<Itest_TypeKind> Kinds { get; set; }

  public test_TypeFilterObject
    ( ICollection<Itest_NameFilter> names
    , ICollection<Itest_NameFilter> aliases
    , ICollection<Itest_TypeKind> kinds
    ) : base(names, aliases)
  {
    Kinds = kinds;
  }
}
