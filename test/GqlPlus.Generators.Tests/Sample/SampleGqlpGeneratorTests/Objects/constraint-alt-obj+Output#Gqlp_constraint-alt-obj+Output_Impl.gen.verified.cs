//HintName: Gqlp_constraint-alt-obj+Output_Impl.gen.cs
// Generated from constraint-alt-obj+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_alt_obj_Output;
public class OutputCnstAltObjOutp
  : ICnstAltObjOutp
{
  public RefCnstAltObjOutp<AltCnstAltObjOutp> AsRefCnstAltObjOutp { get; set; }
}
public class OutputRefCnstAltObjOutp<Tref>
  : IRefCnstAltObjOutp<Tref>
{
  public Tref Asref { get; set; }
}
public class OutputPrntCnstAltObjOutp
  : IPrntCnstAltObjOutp
{
  public String AsString { get; set; }
}
public class OutputAltCnstAltObjOutp
  : OutputPrntCnstAltObjOutp
  , IAltCnstAltObjOutp
{
  public Number alt { get; set; }
}
