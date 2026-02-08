//HintName: test_-Global_Impl.gen.cs
// Generated from -Global.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

public class test_AndType
  : test_Named
  , Itest_AndType
{
  public Itest_Type Type { get; set; }
  public Itest_Type As_Type { get; set; }
  public Itest_AndTypeObject As_AndType { get; set; }
}

public class test_Categories
  : test_AndType
  , Itest_Categories
{
  public Itest_Category Category { get; set; }
  public Itest_Category As_Category { get; set; }
  public Itest_CategoriesObject As_Categories { get; set; }
}

public class test_Category
  : test_Aliased
  , Itest_Category
{
  public Itest_Resolution Resolution { get; set; }
  public Itest_TypeRef<Itest_TypeKind> Output { get; set; }
  public ICollection<Itest_Modifiers> Modifiers { get; set; }
  public Itest_CategoryObject As_Category { get; set; }
}

public class test_Directives
  : test_AndType
  , Itest_Directives
{
  public Itest_Directive Directive { get; set; }
  public Itest_Directive As_Directive { get; set; }
  public Itest_DirectivesObject As_Directives { get; set; }
}

public class test_Directive
  : test_Aliased
  , Itest_Directive
{
  public ICollection<Itest_InputParam> Parameters { get; set; }
  public ItestBoolean Repeatable { get; set; }
  public IDictionary<test_Location, ItestUnit> Locations { get; set; }
  public Itest_DirectiveObject As_Directive { get; set; }
}

public class test_Setting
  : test_Named
  , Itest_Setting
{
  public Itest_Value Value { get; set; }
  public Itest_SettingObject As_Setting { get; set; }
}
