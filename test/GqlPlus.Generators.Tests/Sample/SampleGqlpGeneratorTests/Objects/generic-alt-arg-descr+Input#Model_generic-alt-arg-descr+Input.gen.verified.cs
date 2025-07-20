//HintName: Model_generic-alt-arg-descr+Input.gen.cs
// Generated from generic-alt-arg-descr+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_alt_arg_descr_Input;

public interface IGnrcAltArgDescrInp<Ttype>
{
  RefGnrcAltArgDescrInp<Ttype> AsRefGnrcAltArgDescrInp { get; }
}
public class InputGnrcAltArgDescrInp<Ttype>
  : IGnrcAltArgDescrInp<Ttype>
{
  public RefGnrcAltArgDescrInp<Ttype> AsRefGnrcAltArgDescrInp { get; set; }
}

public interface IRefGnrcAltArgDescrInp<Tref>
{
  Tref Asref { get; }
}
public class InputRefGnrcAltArgDescrInp<Tref>
  : IRefGnrcAltArgDescrInp<Tref>
{
  public Tref Asref { get; set; }
}
