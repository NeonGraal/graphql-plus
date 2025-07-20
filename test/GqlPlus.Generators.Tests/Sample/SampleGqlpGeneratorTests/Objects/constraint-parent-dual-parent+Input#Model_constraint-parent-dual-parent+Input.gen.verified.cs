//HintName: Model_constraint-parent-dual-parent+Input.gen.cs
// Generated from constraint-parent-dual-parent+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_constraint_parent_dual_parent_Input;

public interface ICnstPrntDualPrntInp
  : IRefCnstPrntDualPrntInp
{
}
public class InputCnstPrntDualPrntInp
  : InputRefCnstPrntDualPrntInp
  , ICnstPrntDualPrntInp
{
}

public interface IRefCnstPrntDualPrntInp<Tref>
  : Iref
{
}
public class InputRefCnstPrntDualPrntInp<Tref>
  : Inputref
  , IRefCnstPrntDualPrntInp<Tref>
{
}

public interface IPrntCnstPrntDualPrntInp
{
  String AsString { get; }
}
public class DualPrntCnstPrntDualPrntInp
  : IPrntCnstPrntDualPrntInp
{
  public String AsString { get; set; }
}

public interface IAltCnstPrntDualPrntInp
  : IPrntCnstPrntDualPrntInp
{
  Number alt { get; }
}
public class InputAltCnstPrntDualPrntInp
  : InputPrntCnstPrntDualPrntInp
  , IAltCnstPrntDualPrntInp
{
  public Number alt { get; set; }
}
