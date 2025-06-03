//HintName: Model_constraint-alt-obj+Output.gen.cs
// Generated from constraint-alt-obj+Output.graphql+

/*
*/

namespace GqlTest.Model_constraint_alt_obj_Output;

public interface ICnstAltObjOutp
{
  RefCnstAltObjOutp<AltCnstAltObjOutp> AsRefCnstAltObjOutp { get; }
}
public class OutputCnstAltObjOutp
  : ICnstAltObjOutp
{
  public RefCnstAltObjOutp<AltCnstAltObjOutp> AsRefCnstAltObjOutp { get; set; }
}

public interface IRefCnstAltObjOutp<Tref>
{
  Tref Asref { get; }
}
public class OutputRefCnstAltObjOutp<Tref>
  : IRefCnstAltObjOutp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IPrntCnstAltObjOutp
{
  String AsString { get; }
}
public class OutputPrntCnstAltObjOutp
  : IPrntCnstAltObjOutp
{
  public String AsString { get; set; }
}

public interface IAltCnstAltObjOutp
  : IPrntCnstAltObjOutp
{
  Number alt { get; }
}
public class OutputAltCnstAltObjOutp
  : OutputPrntCnstAltObjOutp
  , IAltCnstAltObjOutp
{
  public Number alt { get; set; }
}
