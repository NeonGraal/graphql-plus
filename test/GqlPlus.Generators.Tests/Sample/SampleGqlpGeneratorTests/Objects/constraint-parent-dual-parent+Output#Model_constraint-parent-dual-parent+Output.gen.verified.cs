//HintName: Model_constraint-parent-dual-parent+Output.gen.cs
// Generated from constraint-parent-dual-parent+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_constraint_parent_dual_parent_Output;

public interface ICnstPrntDualPrntOutp
  : IRefCnstPrntDualPrntOutp
{
}
public class OutputCnstPrntDualPrntOutp
  : OutputRefCnstPrntDualPrntOutp
  , ICnstPrntDualPrntOutp
{
}

public interface IRefCnstPrntDualPrntOutp<Tref>
  : Iref
{
}
public class OutputRefCnstPrntDualPrntOutp<Tref>
  : Outputref
  , IRefCnstPrntDualPrntOutp<Tref>
{
}

public interface IPrntCnstPrntDualPrntOutp
{
  String AsString { get; }
}
public class DualPrntCnstPrntDualPrntOutp
  : IPrntCnstPrntDualPrntOutp
{
  public String AsString { get; set; }
}

public interface IAltCnstPrntDualPrntOutp
  : IPrntCnstPrntDualPrntOutp
{
  Number alt { get; }
}
public class OutputAltCnstPrntDualPrntOutp
  : OutputPrntCnstPrntDualPrntOutp
  , IAltCnstPrntDualPrntOutp
{
  public Number alt { get; set; }
}
