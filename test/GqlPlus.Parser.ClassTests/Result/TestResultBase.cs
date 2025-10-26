namespace GqlPlus.Result;

[TracePerTest]
public abstract class TestResultBase
{
  protected const string Sample = "Sample";
  protected string[] SampleArray { get; } = [Sample];

  // Abstract methods for providing specific result instances
  protected abstract IResult<string> CreateResult();
  protected abstract IResult<string[]> CreateArrayResult();
  protected abstract IResultArray<string> CreateResultArray();

  // Expected behavior descriptors
  protected virtual bool ExpectedHasValue => false;
  protected virtual bool ExpectedIsEmpty => false;
  protected virtual bool ExpectedIsError => false;
  protected virtual bool ExpectedIsOk => false;
  protected abstract string? ExpectedOptionalValue { get; }
  protected virtual bool ExpectedOptionalThrows => false;
  protected virtual bool ExpectedRequiredThrows => false;
  protected abstract string? ExpectedMessage { get; }

  // Expected result types for transformations
  protected virtual Type ExpectedAsResultType => typeof(ResultEmpty<int>);
  protected virtual Type ExpectedAsPartialType => typeof(ResultOk<string>);
  protected virtual Type ExpectedMapType => typeof(ResultOk<string>);
  protected virtual Type ExpectedSelectType => typeof(ResultOk<int>);
  protected virtual Type ExpectedAsResultArrayType => typeof(ResultArrayEmpty<string>);
  protected virtual Type ExpectedAsPartialArrayType => typeof(ResultArrayOk<string>);

  // Expected types for array interface method tests (with <int> parameter)
  protected virtual Type ExpectedArrayAsResultArrayType => typeof(ResultArrayEmpty<int>);
  protected virtual Type ExpectedArrayAsPartialArrayType => typeof(ResultArrayOk<string>);

  // Expected behavior for array results
  protected virtual bool ExpectedArrayOptionalThrows => false;
  protected virtual bool ExpectedArrayRequiredThrows => false;
  protected abstract IEnumerable<string>? ExpectedArrayOptionalValue { get; }

  // Expected callback invocation behavior
  protected virtual bool ExpectedWithValueCalled => false;
  protected virtual bool ExpectedActionCalled => false;

  // Core IResult interface method tests
  [Fact]
  public void AsResult_ReturnsExpectedType()
  {
    IResult<string> result = CreateResult();

    if (ExpectedAsResultType == typeof(NotImplementedException)) {
      Action action = () => result.AsResult<int>();
      action.ShouldThrow<NotImplementedException>();
    } else {
      IResult<int> transformed = result.AsResult<int>();
      transformed.ShouldBeOfType(ExpectedAsResultType);
    }
  }

  [Fact]
  public void AsPartial_ReturnsExpectedType()
  {
    IResult<string> result = CreateResult();
    bool withValueCalled = false;
    bool actionCalled = false;

    if (ExpectedAsPartialType == typeof(NotImplementedException)) {
      Action action = () => result.AsPartial(Sample, v => withValueCalled = true, () => actionCalled = true);
      action.ShouldThrow<NotImplementedException>();
    } else {
      IResult<string> transformed = result.AsPartial(Sample, v => withValueCalled = true, () => actionCalled = true);

      transformed.ShouldSatisfyAllConditions(
        () => transformed.ShouldBeOfType(ExpectedAsPartialType),
        () => withValueCalled.ShouldBe(ExpectedWithValueCalled),
        () => actionCalled.ShouldBe(ExpectedActionCalled));

      if (!ExpectedOptionalThrows) {
        transformed.Optional().ShouldBe(Sample);
      }
    }
  }

  [Fact]
  public void Map_ReturnsExpectedType()
  {
    IResult<string> result = CreateResult();

    if (ExpectedMapType == typeof(NotImplementedException)) {
      Action action = () => result.Map(v => v.Ok(), () => Sample.Ok());
      action.ShouldThrow<NotImplementedException>();
    } else {
      IResult<string> mapped = result.Map(v => v.Ok(), () => Sample.Ok());
      mapped.ShouldBeOfType(ExpectedMapType);
    }
  }

  // IResult extension method tests
  [Fact]
  public void Optional_BehavesAsExpected()
  {
    IResult<string> result = CreateResult();

    if (ExpectedOptionalThrows) {
      Action action = () => result.Optional();
      action.ShouldThrow<InvalidOperationException>();
    } else {
      string? value = result.Optional();
      value.ShouldBe(ExpectedOptionalValue);
    }
  }

  [Fact]
  public void Required_BehavesAsExpected()
  {
    IResult<string> result = CreateResult();

    if (ExpectedRequiredThrows) {
      Action action = () => result.Required();
      action.ShouldThrow<InvalidOperationException>();
    } else {
      string value = result.Required();
      value.ShouldBe(ExpectedOptionalValue);
    }
  }

  [Fact]
  public void HasValue_ReturnsExpected()
  {
    IResult<string> result = CreateResult();

    bool hasValue = result.HasValue();

    hasValue.ShouldBe(ExpectedHasValue);
  }

  [Fact]
  public void IsEmpty_ReturnsExpected()
  {
    IResult<string> result = CreateResult();

    bool isEmpty = result.IsEmpty();

    isEmpty.ShouldBe(ExpectedIsEmpty);
  }

  [Fact]
  public void IsError_ReturnsExpected()
  {
    IResult<string> result = CreateResult();

    bool isError = result.IsError();

    isError.ShouldBe(ExpectedIsError);
  }

  [Fact]
  public void IsOk_ReturnsExpected()
  {
    IResult<string> result = CreateResult();

    bool isOk = result.IsOk();

    isOk.ShouldBe(ExpectedIsOk);
  }

  [Fact]
  public void Select_ReturnsExpectedType()
  {
    IResult<string> result = CreateResult();

    if (ExpectedSelectType == typeof(NotImplementedException)) {
      Action action = () => result.Select(s => s.Length, () => 42.Ok());
      action.ShouldThrow<NotImplementedException>();
    } else {
      IResult<int> selected = result.Select(s => s.Length, () => 42.Ok());
      selected.ShouldBeOfType(ExpectedSelectType);
    }
  }

  [Fact]
  public void WithMessage_CallsActionIfMessage()
  {
    IResult<string> result = CreateResult();
    bool called = false;
    string? receivedMessage = null;

    result.WithMessage(m => {
      called = true;
      receivedMessage = m.Message;
    });

    if (ExpectedMessage != null) {
      called.ShouldBeTrue();
      receivedMessage.ShouldBe(ExpectedMessage);
    } else {
      called.ShouldBeFalse();
    }
  }

  [Fact]
  public void WithResult_CallsActionIfValue()
  {
    IResult<string> result = CreateResult();
    bool called = false;
    string? receivedValue = null;

    result.WithResult(v => {
      called = true;
      receivedValue = v;
    });

    if (ExpectedHasValue) {
      called.ShouldBeTrue();
      receivedValue.ShouldBe(ExpectedOptionalValue);
    } else {
      called.ShouldBeFalse();
    }
  }

  [Fact]
  public void AsResultArray_ReturnsExpectedType()
  {
    IResult<string> result = CreateResult();

    IResultArray<string> resultArray = result.AsResultArray(SampleArray);

    resultArray.ShouldBeOfType(ExpectedAsResultArrayType);
  }

  [Fact]
  public void AsPartialArray_ReturnsExpectedType()
  {
    IResult<string> result = CreateResult();
    bool withValueCalled = false;

    IResultArray<string> resultArray = result.AsPartialArray(SampleArray, v => withValueCalled = true);

    resultArray.ShouldSatisfyAllConditions(
      () => resultArray.ShouldBeOfType(ExpectedAsPartialArrayType),
      () => withValueCalled.ShouldBe(ExpectedWithValueCalled));
  }

  // IResultArray interface method tests
  [Fact]
  public void Array_AsPartial_ReturnsExpectedType()
  {
    IResultArray<string> resultArray = CreateResultArray();
    bool withValueCalled = false;
    bool actionCalled = false;

    if (ExpectedAsPartialType == typeof(NotImplementedException)) {
      Action action = () => resultArray.AsPartial(Sample, v => withValueCalled = true, () => actionCalled = true);
      action.ShouldThrow<NotImplementedException>();
    } else {
      IResult<string> result = resultArray.AsPartial(Sample, v => withValueCalled = true, () => actionCalled = true);

      result.ShouldSatisfyAllConditions(
        () => result.ShouldBeOfType(ExpectedAsPartialType),
        () => withValueCalled.ShouldBe(ExpectedWithValueCalled),
        () => actionCalled.ShouldBe(ExpectedActionCalled));
    }
  }

  [Fact]
  public void Array_AsPartialArray_ReturnsExpectedType()
  {
    IResultArray<string> resultArray = CreateResultArray();
    bool withValueCalled = false;

    if (ExpectedArrayAsPartialArrayType == typeof(NotImplementedException)) {
      Action action = () => resultArray.AsPartialArray(SampleArray, v => withValueCalled = true);
      action.ShouldThrow<NotImplementedException>();
    } else {
      IResultArray<string> result = resultArray.AsPartialArray(SampleArray, v => withValueCalled = true);

      result.ShouldSatisfyAllConditions(
        () => result.ShouldBeOfType(ExpectedArrayAsPartialArrayType),
        () => withValueCalled.ShouldBe(ExpectedWithValueCalled));
    }
  }

  [Fact]
  public void Array_AsResult_ReturnsExpectedType()
  {
    IResultArray<string> resultArray = CreateResultArray();

    if (ExpectedAsResultType == typeof(NotImplementedException)) {
      Action action = () => resultArray.AsResult<int>();
      action.ShouldThrow<NotImplementedException>();
    } else {
      IResult<int> result = resultArray.AsResult<int>();
      result.ShouldBeOfType(ExpectedAsResultType);
    }
  }

  [Fact]
  public void Array_AsResultArray_ReturnsExpectedType()
  {
    IResultArray<string> resultArray = CreateResultArray();

    if (ExpectedArrayAsResultArrayType == typeof(NotImplementedException)) {
      Action action = () => resultArray.AsResultArray<int>();
      action.ShouldThrow<NotImplementedException>();
    } else {
      IResultArray<int> result = resultArray.AsResultArray<int>();
      result.ShouldBeOfType(ExpectedArrayAsResultArrayType);
    }
  }

  [Fact]
  public void Array_Map_ReturnsExpectedType()
  {
    IResultArray<string> resultArray = CreateResultArray();

    if (ExpectedMapType == typeof(NotImplementedException)) {
      Action action = () => resultArray.Map(a => Sample.Ok(), () => Sample.Ok());
      action.ShouldThrow<NotImplementedException>();
    } else {
      IResult<string> result = resultArray.Map(a => Sample.Ok(), () => Sample.Ok());
      result.ShouldBeOfType(ExpectedMapType);
    }
  }

  // IResultArray extension method tests
  [Fact]
  public void Array_Optional_BehavesAsExpected()
  {
    IResultArray<string> resultArray = CreateResultArray();

    if (ExpectedArrayOptionalThrows) {
      Action action = () => resultArray.Optional();
      action.ShouldThrow<InvalidOperationException>();
    } else {
      IEnumerable<string> value = resultArray.Optional();
      value.ShouldBe(ExpectedArrayOptionalValue);
    }
  }

  [Fact]
  public void Array_Required_BehavesAsExpected()
  {
    IResultArray<string> resultArray = CreateResultArray();
    bool called = false;
    IEnumerable<string>? receivedValue = null;

    bool result = resultArray.Required(v => {
      called = true;
      receivedValue = v;
    });

    if (ExpectedArrayRequiredThrows) {
      result.ShouldBeFalse();
      called.ShouldBeFalse();
    } else {
      result.ShouldBeTrue();
      called.ShouldBeTrue();
      receivedValue.ShouldBe(ExpectedArrayOptionalValue);
    }
  }

  [Fact]
  public void Array_WithResult_CallsActionIfValue()
  {
    IResultArray<string> resultArray = CreateResultArray();
    bool called = false;
    IEnumerable<string>? receivedValue = null;

    resultArray.WithResult(v => {
      called = true;
      receivedValue = v;
    });

    if (ExpectedHasValue) {
      called.ShouldBeTrue();
      receivedValue.ShouldBe(ExpectedArrayOptionalValue);
    } else {
      called.ShouldBeFalse();
    }
  }
}
