//HintName: Model_constraint-field-dual+Output.gen.cs
// Generated from constraint-field-dual+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_constraint_field_dual_Output;

public interface ICnstFieldDualOutp
  : IRefCnstFieldDualOutp
{
}
public class OutputCnstFieldDualOutp
  : OutputRefCnstFieldDualOutp
  , ICnstFieldDualOutp
{
}

public interface IRefCnstFieldDualOutp<Tref>
{
  Tref field { get; }
}
public class OutputRefCnstFieldDualOutp<Tref>
  : IRefCnstFieldDualOutp<Tref>
{
  public Tref field { get; set; }
}

public interface IPrntCnstFieldDualOutp
{
  String AsString { get; }
}
public class DualPrntCnstFieldDualOutp
  : IPrntCnstFieldDualOutp
{
  public String AsString { get; set; }
}

public interface IAltCnstFieldDualOutp
  : IPrntCnstFieldDualOutp
{
  Number alt { get; }
}
public class OutputAltCnstFieldDualOutp
  : OutputPrntCnstFieldDualOutp
  , IAltCnstFieldDualOutp
{
  public Number alt { get; set; }
}
