#include "LoginRequestHandler.h"

#define VALID_MSG "{'msg': 'valid login'}"


//C'tors
LoginRequestHandler::LoginRequestHandler(IDatabase& db)
{
	this->m_loginManager = new LoginManager(db);
}
LoginRequestHandler::LoginRequestHandler(LoginManager* man)
{
	this->m_loginManager = man;
}

//is request is relevant?
bool LoginRequestHandler::isRequestRelevant(Request request)
{
	return request.id == LOGIN_REQUEST_ID || request.id == SIGNUP_REQUEST_ID;
}

/*
the func handele login and signup requests
input: the request
output: result
*/
RequestResult LoginRequestHandler::handleRequest(Request request)
{
	//define var
	RequestResult ret;

	// check what request it have
	if (LOGIN_ID == request.id)
	{
		//login
		try
		{
			ret = this->login(request);
		}
		//error
		catch (const std::exception& e)
		{
			cout << e.what() << endl;
		}

	}
	else if (SIGNUP_ID == request.id)
	{
		//signup
		try
		{
			ret = this->signup(request);
		}
		//error
		catch (const std::exception& e)
		{
			cout << e.what() << endl;
		}
	}

	

	ret.newHandler = this;
	return ret;
}

/*
the func handle login request
input: request
output: res
*/
RequestResult LoginRequestHandler::login(Request r)
{
	//define vars and get deserialized req
	LoginRequest deserialized = JsonRequestPacketDeserializer::deserializeLoginRequest(r.buffer);
	RequestResult ret;
	bool error = false;
	char asBits = 0;


	//the user exist?
	if (!this->m_loginManager->doesUserExiste(deserialized.username))
	{
		// no - create error res
		ErrorResponse err;
		err.message = ERROR_ID;
		ret.response = JsonResponsePacketSerializer::serializerResponse(err);
	}
	else
	{
		// yes - login
		try
		{
			this->m_loginManager->login(deserialized.username, deserialized.password);
		}
		catch (const std::exception& e)
		{
			//password incorrect
			error = true;
			cout << e.what() << endl;
			ErrorResponse err;
			err.message = "{'msg':'" + string(e.what()) + "'}";
			ret.response = JsonResponsePacketSerializer::serializerResponse(err);
			ret.msg = err.message;
		}
		if (!error)
		{
			//create login res 
			LoginResponse log;
			log.status = TRIVIA_OK;
			//Add the status to the messge.
			ret.response = JsonResponsePacketSerializer::serializerResponse(log);
			//Add the messge length to the first message.
		}
	}

	return ret;
}

/*
The function handle signup request
Input: request to handler
Output: RequestResult - the result of the handle 
*/
RequestResult LoginRequestHandler::signup(Request r)
{
	//define vars and get deserialized req
	SignupRequest deserialized = JsonRequestPacketDeserializer::deserializeSignupRequest(r.buffer);
	RequestResult ret;
	SignupResponse resp;

	//signup
	try
	{
		this->m_loginManager->signup(deserialized.username, deserialized.password, deserialized.email);
	}
	catch (const std::exception& e)
	{
		cout << e.what() << endl;
	}	
	
	//create signup result
	resp.status = TRIVIA_OK;
	ret.response = JsonResponsePacketSerializer::serializerResponse(resp);
	ret.msg = to_string(resp.status) + to_string(ret.response.size());
	return ret;
}

