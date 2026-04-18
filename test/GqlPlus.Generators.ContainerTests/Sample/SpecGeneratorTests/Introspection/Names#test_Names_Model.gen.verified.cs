//HintName: test_Names_Model.gen.cs
// Generated from {CurrentDirectory}Names.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpModelBase, GeneratorType: Model
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Names;

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

  public test_AliasedObject
    ( ICollection<string> description
    , Itest_Name name
    , ICollection<Itest_Name> aliases
    ) : base(description, name)
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

  public test_NamedObject
    ( ICollection<string> description
    , Itest_Name name
    ) : base(description)
  {
    Name = name;
  }
}

public class test_Described
  : GqlpModelBase
  , Itest_Described
{
  public Itest_DescribedObject? As__Described { get; set; }
}

public class test_DescribedObject
  : GqlpModelBase
  , Itest_DescribedObject
{
  public ICollection<string> Description { get; set; }

  public test_DescribedObject
    ( ICollection<string> description
    )
  {
    Description = description;
  }
}

public class test_AndType
  : test_Named
  , Itest_AndType
{
  public Itest_Type? As_Type { get; set; }
  public Itest_AndTypeObject? As__AndType { get; set; }
}

public class test_AndTypeObject
  : test_NamedObject
  , Itest_AndTypeObject
{
  public Itest_Type Type { get; set; }

  public test_AndTypeObject
    ( ICollection<string> description
    , Itest_Name name
    , Itest_Type type
    ) : base(description, name)
  {
    Type = type;
  }
}
