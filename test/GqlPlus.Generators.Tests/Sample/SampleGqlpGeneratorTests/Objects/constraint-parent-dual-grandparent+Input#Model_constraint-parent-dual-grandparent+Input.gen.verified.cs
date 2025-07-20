//HintName: Model_constraint-parent-dual-grandparent+Input.gen.cs
// Generated from constraint-parent-dual-grandparent+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_constraint_parent_dual_grandparent_Input;

public interface ICnstPrntDualGrndInp
  : IRefCnstPrntDualGrndInp
{
}
public class InputCnstPrntDualGrndInp
  : InputRefCnstPrntDualGrndInp
  , ICnstPrntDualGrndInp
{
}

public interface IRefCnstPrntDualGrndInp<Tref>
  : Iref
{
}
public class InputRefCnstPrntDualGrndInp<Tref>
  : Inputref
  , IRefCnstPrntDualGrndInp<Tref>
{
}

public interface IGrndCnstPrntDualGrndInp
{
  String AsString { get; }
}
public class DualGrndCnstPrntDualGrndInp
  : IGrndCnstPrntDualGrndInp
{
  public String AsString { get; set; }
}

public interface IPrntCnstPrntDualGrndInp
  : IGrndCnstPrntDualGrndInp
{
}
public class DualPrntCnstPrntDualGrndInp
  : DualGrndCnstPrntDualGrndInp
  , IPrntCnstPrntDualGrndInp
{
}

public interface IAltCnstPrntDualGrndInp
  : IPrntCnstPrntDualGrndInp
{
  Number alt { get; }
}
public class InputAltCnstPrntDualGrndInp
  : InputPrntCnstPrntDualGrndInp
  , IAltCnstPrntDualGrndInp
{
  public Number alt { get; set; }
}
