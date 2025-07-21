//HintName: Gqlp_Intro_+Global_Impl.gen.cs
// Generated from Intro_+Global.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Intro__Global;
public class Output_Categories
  : I_Categories
{
  public _Category category { get; set; }
  public _Type type { get; set; }
  public _Category As_Category { get; set; }
  public _Type As_Type { get; set; }
}
public class Output_Category
  : Output_Aliased
  , I_Category
{
  public _Resolution resolution { get; set; }
  public _TypeRef<_TypeKind> name { get; set; }
  public _Modifiers modifiers { get; set; }
}
public class Output_Directives
  : I_Directives
{
  public _Directive directive { get; set; }
  public _Type type { get; set; }
  public _Directive As_Directive { get; set; }
  public _Type As_Type { get; set; }
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
  public _Constant value { get; set; }
}
