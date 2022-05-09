for i in {1..50};
do
	dotnet build "Portal.csproj"
	if [ $? -eq 0 ]
	then
		echo "Portal build completed"
		break
	else
		echo "not ready yet..."
		sleep 1
	fi
done
