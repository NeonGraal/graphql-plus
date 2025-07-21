//HintName: Gqlp_constraint-field-obj+Output_Impl.gen.cs
// Generated from constraint-field-obj+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_field_obj_Output;
public class OutputCnstFieldObjOutp
  : OutputRefCnstFieldObjOutp
  , ICnstFieldObjOutp
{
}
public class OutputRefCnstFieldObjOutp<Tref>
  : IRefCnstFieldObjOutp<Tref>
{
  public Tref field { get; set; }
}
public class OutputPrntCnstFieldObjOutp
  : IPrntCnstFieldObjOutp
{
  public String AsString { get; set; }
}
public class OutputAltCnstFieldObjOutp
  : OutputPrntCnstFieldObjOutp
  , IAltCnstFieldObjOutp
{
  public Number alt { get; set; }
}
