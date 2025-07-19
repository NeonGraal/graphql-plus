//HintName: Model_constraint-alt-obj+Dual.gen.cs
// Generated from constraint-alt-obj+Dual.graphql+

/*
*/

namespace GqlTest.Model_constraint_alt_obj_Dual;

public interface ICnstAltObjDual
{
  RefCnstAltObjDual<AltCnstAltObjDual> AsRefCnstAltObjDual { get; }
}
public class DualCnstAltObjDual
  : ICnstAltObjDual
{
  public RefCnstAltObjDual<AltCnstAltObjDual> AsRefCnstAltObjDual { get; set; }
}

public interface IRefCnstAltObjDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefCnstAltObjDual<Tref>
  : IRefCnstAltObjDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IPrntCnstAltObjDual
{
  String AsString { get; }
}
public class DualPrntCnstAltObjDual
  : IPrntCnstAltObjDual
{
  public String AsString { get; set; }
}

public interface IAltCnstAltObjDual
  : IPrntCnstAltObjDual
{
  Number alt { get; }
}
public class DualAltCnstAltObjDual
  : DualPrntCnstAltObjDual
  , IAltCnstAltObjDual
{
  public Number alt { get; set; }
}
