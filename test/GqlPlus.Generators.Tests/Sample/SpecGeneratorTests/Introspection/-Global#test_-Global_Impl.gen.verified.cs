//HintName: test_-Global_Impl.gen.cs
// Generated from -Global.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp__Global;

public class Outputtest_AndType
  : Outputtest_Named
  , Itest_AndType
{
  public _Type type { get; set; }
  public _Type As_Type { get; set; }
}

public class Outputtest_Categories
  : Outputtest_AndType
  , Itest_Categories
{
  public _Category category { get; set; }
  public _Category As_Category { get; set; }
}

public class Outputtest_Category
  : Outputtest_Aliased
  , Itest_Category
{
  public _Resolution resolution { get; set; }
  public _TypeRef<_TypeKind> output { get; set; }
  public _Modifiers modifiers { get; set; }
}

public class Outputtest_Directives
  : Outputtest_AndType
  , Itest_Directives
{
  public _Directive directive { get; set; }
  public _Directive As_Directive { get; set; }
}

public class Outputtest_Directive
  : Outputtest_Aliased
  , Itest_Directive
{
  public _InputParam parameters { get; set; }
  public Boolean repeatable { get; set; }
  public Unit locations { get; set; }
}

public class Outputtest_Setting
  : Outputtest_Named
  , Itest_Setting
{
  public _Value value { get; set; }
}
