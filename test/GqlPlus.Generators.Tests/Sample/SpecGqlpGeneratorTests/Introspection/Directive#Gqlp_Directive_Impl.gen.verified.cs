//HintName: Gqlp_Directive_Impl.gen.cs
// Generated from Directive.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_Directive;

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
