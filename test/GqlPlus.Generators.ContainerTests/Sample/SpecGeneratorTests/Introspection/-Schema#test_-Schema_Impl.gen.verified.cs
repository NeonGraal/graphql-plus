//HintName: test_-Schema_Impl.gen.cs
// Generated from {CurrentDirectory}-Schema.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelImplementationBase, GeneratorType: Impl
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Schema;

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

  public test_SchemaObject(ICollection<string> description, Itest_Name name)
    : base(description, name)
  {
  }
}

public class test_Name
  : GqlpDomainString
  , Itest_Name
{
}

public class test_Filter
  : GqlpModelImplementationBase
  , Itest_Filter
{
  public ICollection<Itest_NameFilter>? As_NameFilter { get; set; }
  public Itest_FilterObject? As__Filter { get; set; }
}

public class test_FilterObject
  : GqlpModelImplementationBase
  , Itest_FilterObject
{
  public ICollection<Itest_NameFilter> Names { get; set; }
  public bool? MatchAliases { get; set; }
  public ICollection<Itest_NameFilter> Aliases { get; set; }
  public bool? ReturnByAlias { get; set; }
  public bool? ReturnReferencedTypes { get; set; }

  public test_FilterObject(ICollection<Itest_NameFilter> names, ICollection<Itest_NameFilter> aliases)
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

  public test_CategoryFilterObject(ICollection<Itest_NameFilter> names, ICollection<Itest_NameFilter> aliases, ICollection<Itest_Resolution> resolutions)
    : base(names, aliases)
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

  public test_TypeFilterObject(ICollection<Itest_NameFilter> names, ICollection<Itest_NameFilter> aliases, ICollection<Itest_TypeKind> kinds)
    : base(names, aliases)
  {
    Kinds = kinds;
  }
}

public class test_Aliased
  : test_Named
  , Itest_Aliased
{
  public Itest_AliasedObject? As__Aliased { get; set; }
}

public class test_AliasedObject
  : test_NamedObject
  , Itest_AliasedObject
{
  public ICollection<Itest_Name> Aliases { get; set; }

  public test_AliasedObject(ICollection<string> description, Itest_Name name, ICollection<Itest_Name> aliases)
    : base(description, name)
  {
    Aliases = aliases;
  }
}

public class test_Named
  : test_Described
  , Itest_Named
{
  public Itest_NamedObject? As__Named { get; set; }
}

public class test_NamedObject
  : test_DescribedObject
  , Itest_NamedObject
{
  public Itest_Name Name { get; set; }

  public test_NamedObject(ICollection<string> description, Itest_Name name)
    : base(description)
  {
    Name = name;
  }
}

public class test_Described
  : GqlpModelImplementationBase
  , Itest_Described
{
  public Itest_DescribedObject? As__Described { get; set; }
}

public class test_DescribedObject
  : GqlpModelImplementationBase
  , Itest_DescribedObject
{
  public ICollection<string> Description { get; set; }

  public test_DescribedObject(ICollection<string> description)
  {
    Description = description;
  }
}
