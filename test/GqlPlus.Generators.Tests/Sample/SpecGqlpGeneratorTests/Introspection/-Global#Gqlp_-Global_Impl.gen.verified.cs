//HintName: Gqlp_-Global_Impl.gen.cs
// Generated from -Global.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp__Global;

public class Output_AndType
  : Output_Named
  , I_AndType
{
  public _Type type { get; set; }
  public _Type As_Type { get; set; }
}

public class Output_Categories
  : Output_AndType
  , I_Categories
{
  public _Category category { get; set; }
  public _Category As_Category { get; set; }
}

public class Output_Category
  : Output_Aliased
  , I_Category
{
  public _Resolution resolution { get; set; }
  public _TypeRef<_TypeKind> output { get; set; }
  public _Modifiers modifiers { get; set; }
}

public class Output_Directives
  : Output_AndType
  , I_Directives
{
  public _Directive directive { get; set; }
  public _Directive As_Directive { get; set; }
}

public class Output_Directive
  : Output_Aliased
  , I_Directive
{
  public _InputParam parameters { get; set; }
  public Boolean repeatable { get; set; }
  public Unit locations { get; set; }
}

public class Output_Setting
  : Output_Named
  , I_Setting
{
  public _Value value { get; set; }
}
