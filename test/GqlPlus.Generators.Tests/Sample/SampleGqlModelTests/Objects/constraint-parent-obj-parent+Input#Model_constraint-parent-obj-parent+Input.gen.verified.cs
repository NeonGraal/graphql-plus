//HintName: Model_constraint-parent-obj-parent+Input.gen.cs
// Generated from constraint-parent-obj-parent+Input.graphql+

/*
*/

namespace GqlTest.Model_constraint_parent_obj_parent_Input;

public interface ICnstPrntObjPrntInp
  : IRefCnstPrntObjPrntInp
{
}
public class InputCnstPrntObjPrntInp
  : InputRefCnstPrntObjPrntInp
  , ICnstPrntObjPrntInp
{
}

public interface IRefCnstPrntObjPrntInp<Tref>
  : Iref
{
}
public class InputRefCnstPrntObjPrntInp<Tref>
  : Inputref
  , IRefCnstPrntObjPrntInp<Tref>
{
}

public interface IPrntCnstPrntObjPrntInp
{
  String AsString { get; }
}
public class InputPrntCnstPrntObjPrntInp
  : IPrntCnstPrntObjPrntInp
{
  public String AsString { get; set; }
}

public interface IAltCnstPrntObjPrntInp
  : IPrntCnstPrntObjPrntInp
{
  Number alt { get; }
}
public class InputAltCnstPrntObjPrntInp
  : InputPrntCnstPrntObjPrntInp
  , IAltCnstPrntObjPrntInp
{
  public Number alt { get; set; }
}
