//HintName: test_-Global_Enc.gen.cs
// Generated from {CurrentDirectory}-Global.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

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
    ( Itest_Type type
    )
  {
    Type = type;
  }
}

public class test_Categories
  : test_AndType
  , Itest_Categories
{
  public Itest_Category? As_Category { get; set; }
  public Itest_CategoriesObject? As__Categories { get; set; }
}

public class test_CategoriesObject
  : test_AndTypeObject
  , Itest_CategoriesObject
{
  public Itest_Category Category { get; set; }

  public test_CategoriesObject
    ( Itest_Type type
    , Itest_Category category
    ) : base(type)
  {
    Category = category;
  }
}

public class test_Category
  : test_Aliased
  , Itest_Category
{
  public Itest_CategoryObject? As__Category { get; set; }
}

public class test_CategoryObject
  : test_AliasedObject
  , Itest_CategoryObject
{
  public test_Resolution Resolution { get; set; }
  public Itest_TypeRef<Itest_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }

  public test_CategoryObject
    ( test_Resolution resolution
    , Itest_TypeRef<Itest_TypeKind> output
    , ICollection<Itest_Modifiers> modifiers
    )
  {
    Resolution = resolution;
    Output = output;
    Modifiers = modifiers;
  }
}

public enum test_Resolution
{
  Parallel,
  Sequential,
  Single,
}

public class test_Directives
  : test_AndType
  , Itest_Directives
{
  public Itest_Directive? As_Directive { get; set; }
  public Itest_DirectivesObject? As__Directives { get; set; }
}

public class test_DirectivesObject
  : test_AndTypeObject
  , Itest_DirectivesObject
{
  public Itest_Directive Directive { get; set; }

  public test_DirectivesObject
    ( Itest_Type type
    , Itest_Directive directive
    ) : base(type)
  {
    Directive = directive;
  }
}

public class test_Directive
  : test_Aliased
  , Itest_Directive
{
  public Itest_DirectiveObject? As__Directive { get; set; }
}

public class test_DirectiveObject
  : test_AliasedObject
  , Itest_DirectiveObject
{
  public Itest_InputFieldType? Parameter { get; set; }
  public bool Repeatable { get; set; }
  public IDictionary<test_Location, GqlpUnit> Locations { get; set; }

  public test_DirectiveObject
    ( bool repeatable
    , IDictionary<test_Location, GqlpUnit> locations
    )
  {
    Repeatable = repeatable;
    Locations = locations;
  }
}

public enum test_Location
{
  Operation,
  Variable,
  Field,
  Inline,
  Spread,
  Fragment,
}

public class test_Setting
  : test_Named
  , Itest_Setting
{
  public Itest_SettingObject? As__Setting { get; set; }
}

public class test_SettingObject
  : test_NamedObject
  , Itest_SettingObject
{
  public GqlpValue Value { get; set; }

  public test_SettingObject
    ( GqlpValue value
    )
  {
    Value = value;
  }
}
