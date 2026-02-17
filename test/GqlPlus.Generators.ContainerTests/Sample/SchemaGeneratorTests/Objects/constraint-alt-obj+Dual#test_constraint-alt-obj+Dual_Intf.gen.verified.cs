//HintName: test_constraint-alt-obj+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

public interface ItestCnstAltObjDual
  : IGqlpModelImplementationBase
{
  ItestRefCnstAltObjDual<ItestAltCnstAltObjDual> AsRefCnstAltObjDual { get; }
  ItestCnstAltObjDualObject AsCnstAltObjDual { get; }
}

public interface ItestCnstAltObjDualObject
{
}

public interface ItestRefCnstAltObjDual<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefCnstAltObjDualObject<TRef> AsRefCnstAltObjDual { get; }
}

public interface ItestRefCnstAltObjDualObject<TRef>
{
}

public interface ItestPrntCnstAltObjDual
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestPrntCnstAltObjDualObject AsPrntCnstAltObjDual { get; }
}

public interface ItestPrntCnstAltObjDualObject
{
}

public interface ItestAltCnstAltObjDual
  : ItestPrntCnstAltObjDual
{
  ItestAltCnstAltObjDualObject AsAltCnstAltObjDual { get; }
}

public interface ItestAltCnstAltObjDualObject
  : ItestPrntCnstAltObjDualObject
{
  decimal Alt { get; }
}
