//HintName: test_-Global_Impl.gen.cs
// Generated from -Global.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Global;

public class test_AndType
  : test_Named
  , Itest_AndType
{
  public test_Type type { get; set; }
  public test_Type As_Type { get; set; }
  public test_AndType _AndType { get; set; }
}

public class test_Categories
  : test_AndType
  , Itest_Categories
{
  public test_Category category { get; set; }
  public test_Category As_Category { get; set; }
  public test_Categories _Categories { get; set; }
}

public class test_Category
  : test_Aliased
  , Itest_Category
{
  public test_Resolution resolution { get; set; }
  public test_TypeRef<test_TypeKind> output { get; set; }
  public ICollection<test_Modifiers> modifiers { get; set; }
  public test_Category _Category { get; set; }
}

public class test_Directives
  : test_AndType
  , Itest_Directives
{
  public test_Directive directive { get; set; }
  public test_Directive As_Directive { get; set; }
  public test_Directives _Directives { get; set; }
}

public class test_Directive
  : test_Aliased
  , Itest_Directive
{
  public ICollection<test_InputParam> parameters { get; set; }
  public testBoolean repeatable { get; set; }
  public IDictionary<test_Location, testUnit> locations { get; set; }
  public test_Directive _Directive { get; set; }
}

public class test_Setting
  : test_Named
  , Itest_Setting
{
  public test_Value value { get; set; }
  public test_Setting _Setting { get; set; }
}
