namespace session09C_
{
    
        internal class Program
        {
            static void Main(string[] args)
            {
                #region Part 1 - Q2: Compare two identical Patient objects
                Console.WriteLine("===== Part 1 - Q2 =====");
                Patient patient01 = new Patient(1, "Ahmed Ali", "0100000000", "Diabetes");
                Patient patient02 = new Patient(1, "Ahmed Ali", "0100000000", "Diabetes");

                Console.WriteLine("patient01.GetHashCode() = " + patient01.GetHashCode());
                Console.WriteLine("patient02.GetHashCode() = " + patient02.GetHashCode());
                // Different hash codes: class's default GetHashCode() is based on
                // the object's identity/reference in memory, not its field values.

                Console.WriteLine("patient01.Equals(patient02) = " + patient01.Equals(patient02));
                // False: default Equals() for a class does Reference Equality
                // (are they the same object in memory?), not Value Equality.

                patient01 = patient02;
                Console.WriteLine("After patient01 = patient02:");
                Console.WriteLine("patient01.Equals(patient02) = " + patient01.Equals(patient02));
                // True now: patient01 points to the exact same object as patient02
                // (same reference), not because their values matched separately.
                #endregion

                Console.WriteLine();

                #region Part 1 - Q3: PatientDto record comparison
                Console.WriteLine("===== Part 1 - Q3 =====");
                PatientDto dto01 = new PatientDto(1, "Ahmed Ali", "0100000000");
                PatientDto dto02 = new PatientDto(1, "Ahmed Ali", "0100000000");

                Console.WriteLine("dto01.GetHashCode() = " + dto01.GetHashCode());
                Console.WriteLine("dto02.GetHashCode() = " + dto02.GetHashCode());
                // Equal hash codes: records automatically generate GetHashCode()
                // based on the values of their properties.

                Console.WriteLine("dto01.Equals(dto02) = " + dto01.Equals(dto02));
                // True: records automatically implement Value Equality,
                // comparing property values instead of references.

                // Difference between class and record (as observed above):
                // - class (Patient): Equals()/GetHashCode() compare by REFERENCE (identity).
                //   Two separate "new" objects with identical data are NOT equal.
                // - record (PatientDto): Equals()/GetHashCode() compare by VALUE automatically.
                //   Two separate "new" objects with identical data ARE equal.
                #endregion

                Console.WriteLine();

                #region Part 1 - Q4: PatientMapper
                Console.WriteLine("===== Part 1 - Q4 =====");
                Patient fullPatient = new Patient(5, "Sara Mostafa", "0111111111", "Asthma");
                PatientDto mappedDto = PatientMapper.MapFromModelToDto(fullPatient);
                Console.WriteLine(mappedDto);
                #endregion

                Console.WriteLine();

                #region Part 2 - Q6: Singleton Test
                Console.WriteLine("===== Part 2 - Q6 =====");
                AppLogger logger1 = AppLogger.GetLogger();
                AppLogger logger2 = AppLogger.GetLogger();
                AppLogger logger3 = AppLogger.GetLogger();
                AppLogger logger4 = AppLogger.GetLogger();

                Console.WriteLine("logger1.GetHashCode() = " + logger1.GetHashCode());
                Console.WriteLine("logger2.GetHashCode() = " + logger2.GetHashCode());
                Console.WriteLine("logger3.GetHashCode() = " + logger3.GetHashCode());
                Console.WriteLine("logger4.GetHashCode() = " + logger4.GetHashCode());
                // All four hash codes are IDENTICAL, because GetLogger() only creates
                // a new AppLogger instance the FIRST time it's called (when _instance is null).
                // Every subsequent call returns that same stored instance,
                // so all four variables actually reference the exact same object in memory.
                // Notice "AppLogger instance created." is printed only ONCE.
                #endregion

                Console.WriteLine();

                #region Part 3 - Q7: var & dynamic
                Console.WriteLine("===== Part 3 - Q7 =====");

                // 1. Target-typed new
                Patient p1 = new(10, "Mona Adel", "0122222222", "None");
                Console.WriteLine(p1);

                // 2. var
                var p2 = new Patient(11, "Khaled Samir", "0133333333", "Hypertension");
                Console.WriteLine(p2);

                // 3. dynamic
                dynamic p3 = new Patient(12, "Laila Hassan", "0144444444", "None");
                Console.WriteLine(p3);

                // Difference between var and dynamic:
                // - var: the type is determined at COMPILE TIME. The compiler looks at
                //   the right-hand side expression and locks in the actual type (Patient)
                //   right then. IntelliSense, type-checking, and errors for invalid members
                //   all happen at compile time, exactly as if you'd written "Patient p2 = ...".
                // - dynamic: the type is resolved at RUNTIME. The compiler does NOT check
                //   member access at compile time; it skips all type checking and only
                //   figures out at runtime whether the member/method actually exists on
                //   the real underlying object. This means typos or invalid members
                //   compile fine but throw a RuntimeBinderException when the program runs.
                #endregion

                Console.WriteLine();

                #region Part 4 - Q8: Anonymous Types
                Console.WriteLine("===== Part 4 - Q8 =====");
                var doctor01 = new { Name = "Sara", Specialty = "Cardiology", ExperienceYears = 8, Salary = 25_000 };
                var doctor02 = new { Name = "Sara", Specialty = "Cardiology", ExperienceYears = 8, Salary = 25_000 };

                // 1.
                Console.WriteLine("doctor01.Name = " + doctor01.Name);
                Console.WriteLine("doctor01.Specialty = " + doctor01.Specialty);

                // 2.
                Console.WriteLine("doctor01.GetHashCode() = " + doctor01.GetHashCode());
                Console.WriteLine("doctor02.GetHashCode() = " + doctor02.GetHashCode());
                // Equal hash codes: anonymous types, like records, auto-generate
                // GetHashCode()/Equals() based on the values of their properties.

                // 3.
                Console.WriteLine("doctor01.GetType() = " + doctor01.GetType());

                // 4.
                Console.WriteLine("doctor01.Equals(doctor02) = " + doctor01.Equals(doctor02));
                // True: same reason as hash codes above - Value Equality.

                // 5.
                Console.WriteLine("doctor01.ToString() = " + doctor01.ToString());

                // Comparison of equality behavior:
                // - class (Patient):        Reference Equality (default) -> separate "new" objects with same data are NOT equal.
                // - record (PatientDto):    Value Equality (built-in)    -> separate "new" objects with same data ARE equal.
                // - anonymous type (doctor): Value Equality (built-in)    -> separate objects with same property names/values/types ARE equal.
                //   (Anonymous types behave like records for equality, but only when declared with IDENTICAL property names, order and types.)
                #endregion

                Console.WriteLine();

                #region Part 5 - Q10: Extension Methods
                Console.WriteLine("===== Part 5 - Q10 =====");
                Console.WriteLine("\"Stethoscope\".IsShorterThan(5) = " + "Stethoscope".IsShorterThan(5));
                Console.WriteLine("\"Ab\".Repeat(4) = " + "Ab".Repeat(4));
                #endregion
            }
        }
    }

