//HintName: test_-Global_Impl.gen.cs
// Generated from -Global.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp__Global;

public class test_AndType
  : test_Named
  , Itest_AndType
{
  public _Type type { get; set; }
  public _Type As_Type { get; set; }
}

public class test_Categories
  : test_AndType
  , Itest_Categories
{
  public _Category category { get; set; }
  public _Category As_Category { get; set; }
}

public class test_Category
  : test_Aliased
  , Itest_Category
{
  public _Resolution resolution { get; set; }
  public _TypeRef<_TypeKind> output { get; set; }
  public _Modifiers modifiers { get; set; }
}

public class test_Directives
  : test_AndType
  , Itest_Directives
{
  public _Directive directive { get; set; }
  public _Directive As_Directive { get; set; }
}

public class test_Directive
  : test_Aliased
  , Itest_Directive
{
  public _InputParam parameters { get; set; }
  public Boolean repeatable { get; set; }
  public Unit locations { get; set; }
}

public class test_Setting
  : test_Named
  , Itest_Setting
{
  public _Value value { get; set; }
}
