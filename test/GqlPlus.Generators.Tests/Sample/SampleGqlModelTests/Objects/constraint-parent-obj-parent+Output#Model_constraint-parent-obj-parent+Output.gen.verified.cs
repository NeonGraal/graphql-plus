//HintName: Model_constraint-parent-obj-parent+Output.gen.cs
// Generated from constraint-parent-obj-parent+Output.graphql+

/*
*/

namespace GqlTest.Model_constraint_parent_obj_parent_Output;

public interface ICnstPrntObjPrntOutp
  : IRefCnstPrntObjPrntOutp
{
}
public class OutputCnstPrntObjPrntOutp
  : OutputRefCnstPrntObjPrntOutp
  , ICnstPrntObjPrntOutp
{
}

public interface IRefCnstPrntObjPrntOutp<Tref>
  : Iref
{
}
public class OutputRefCnstPrntObjPrntOutp<Tref>
  : Outputref
  , IRefCnstPrntObjPrntOutp<Tref>
{
}

public interface IPrntCnstPrntObjPrntOutp
{
  String AsString { get; }
}
public class OutputPrntCnstPrntObjPrntOutp
  : IPrntCnstPrntObjPrntOutp
{
  public String AsString { get; set; }
}

public interface IAltCnstPrntObjPrntOutp
  : IPrntCnstPrntObjPrntOutp
{
  Number alt { get; }
}
public class OutputAltCnstPrntObjPrntOutp
  : OutputPrntCnstPrntObjPrntOutp
  , IAltCnstPrntObjPrntOutp
{
  public Number alt { get; set; }
}
